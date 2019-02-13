using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using pr_calculator.models;
using System.Globalization;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace pr_calculator
{
    public partial class PR : Form
    {

        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        List<Member> members;
        List<SwimStyle> swimStyles;
        DateTime fromDate;
        DateTime tillDate;
        string filePath = "";
        string title = "pr competitie";
        bool addDate = true;
        public PR()
        {
            InitializeComponent();
            fromDate = DateTime.Now;
            tillDate = DateTime.Now;
        }

        public void getSwimStyles() {
            da = new OleDbDataAdapter("SELECT * FROM SWIMSTYLE", con);
            ds = new DataSet();
            swimStyles = new List<SwimStyle>();
            da.Fill(ds, "SWIMSTYLE");
            foreach (DataRow row in ds.Tables["SWIMSTYLE"].Rows)
            {
                SwimStyle s;
                s = new SwimStyle(
                    Convert.ToInt32(row["SWIMSTYLEID"]),
                    Convert.ToInt32(row["DISTANCE"]),
                    Convert.ToInt32(row["STROKE"])
                );
                swimStyles.Add(s);
            }
        }

        SwimStyle getSwimStyleById(int id) {
            SwimStyle s = null;
            foreach (SwimStyle swimStyle in swimStyles){
                if (swimStyle.id == id) {
                    s = swimStyle;
                }
            }
            return s;
        }

        Dictionary<SwimStyle, List<Record>> getRecordsTillFromDate(Member m) {
            Dictionary<SwimStyle, List<Record>> records = new Dictionary<SwimStyle, List<Record>>();
            foreach (SwimStyle s in swimStyles)
            {
                da = new OleDbDataAdapter("SELECT MIN(TOTALTIME) AS FASTEST FROM RESULTS WHERE MEMBERSID = " + m.id.ToString() + "AND EVENTDATE < #" + fromDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) + "# AND STYLESID = " + s.id + " AND TOTALTIME > 0;", con);
                ds = new DataSet();
                da.Fill(ds, "RESULTS");
                foreach (DataRow row in ds.Tables["RESULTS"].Rows)
                {
                    if (row["FASTEST"].GetType() != typeof(DBNull))
                    {
                        Record r = new Record(
                            DateTime.Now,
                            s,
                            Convert.ToInt32(row["FASTEST"])
                        );
                        m.addRecord(r);
                    }
                };
            }
            return records;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filePath.Length < 1)
            {
                MessageBox.Show("Please select a file.");
            }
            else
            {
                Console.WriteLine(filePath);
                con = new OleDbConnection("Provider = Microsoft.ACE.Oledb.12.0; Data Source = " + filePath);

                members = new List<Member>();
                con.Open();
                getSwimStyles();
                da = new OleDbDataAdapter("SELECT * FROM MEMBERS", con);
                ds = new DataSet();
                da.Fill(ds, "MEMBERS");

                foreach (DataRow row in ds.Tables["MEMBERS"].Rows)
                {
                    if (row.ItemArray[0] != DBNull.Value)
                    {
                        Member m;
                        Gender gender = Gender.female;
                        if (Convert.ToInt32(row["GENDER"]) == 1)
                        {
                            gender = Gender.male;
                        }

                        m = new Member
                        (
                            Convert.ToInt32(row["MEMBERSID"]),
                            Convert.ToString(row["FIRSTNAME"]),
                            Convert.ToString(row["NAMEPREFIX"]) + " " + Convert.ToString(row["LASTNAME"]),
                            (DateTime)row["BIRTHDATE"],
                            Convert.ToInt32(row["REGISTRATIONID"]),
                            gender
                        );
                        members.Add(m);
                    }
                }
            
                foreach (Member m in members)
                {
                    Dictionary<SwimStyle, List<Record>> currentRecords = getRecordsTillFromDate(m);

                    string query = "SELECT * FROM RESULTS WHERE MEMBERSID = " + m.id.ToString() + " AND EVENTDATE <= #" + tillDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) + "# AND EVENTDATE >= #" + fromDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) + "# AND TOTALTIME > 0; ";
                    da = new OleDbDataAdapter(query, con);
                    ds = new DataSet();
                    da.Fill(ds, "RESULTS");

                    foreach (DataRow row in ds.Tables["RESULTS"].Rows)
                    {
                        if (row.ItemArray[0] != DBNull.Value)
                        {
                            //add all results in a list ordered by date
                            Result r = new Result(
                                    Convert.ToDateTime(row["EVENTDATE"]),
                                    getSwimStyleById(Convert.ToInt32(row["STYLESID"])),
                                    Convert.ToInt32(row["TOTALTIME"])
                                );
                            m.results.Add(r);
                        }
                    }
                }
                //datagrid.DataSource = ds.Tables["MEMBERS"];
                con.Close();
                //done with the db work
                Console.WriteLine("done with db work");
                foreach (Member m in members)
                {
                    List<Result> resultsbyDate;
                    resultsbyDate = new List<Result>(m.results.OrderBy(r => r.eventDate).ThenBy(r => r.eventDate).ToList());
                    for (int i = 0; i < resultsbyDate.Count; i++)
                    {
                        Result currentResult = resultsbyDate[i];

                        if (m.records.ContainsKey(currentResult.swimStyle))
                        {
                            Record r = m.records[currentResult.swimStyle];
                            if (r.time > currentResult.time)
                            {
                                Record newRecord = new Record(
                                    currentResult.eventDate,
                                    currentResult.swimStyle,
                                    currentResult.time,
                                    r.timeAsTimeSpan
                                );

                                newRecord.oldRecord = r.timeAsTimeSpan;
                                m.addRecord(newRecord);
                                m.addNewRecord(newRecord);
                            }
                        }
                        else
                        {
                            Record newRecord = new Record(
                                currentResult.eventDate,
                                currentResult.swimStyle,
                                currentResult.time
                            );

                            m.addRecord(newRecord);
                        }
                    }
                }
                //time to make the pdf
                Document document = new Document();
                Section section = document.AddSection();         
                Paragraph paragraph = section.AddParagraph();
                paragraph.Format.Font.Color = Colors.Black;
                paragraph.Format.Font.Size = 20;
                document.UseCmykColor = true;
                const bool unicode = false;
                const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
                
                paragraph.AddFormattedText("pr's between " + fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + " and " + tillDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));

                foreach (Member m in members)
                {
                    if (m.newRecords.Count < 1) {
                        continue;
                    }
                    Paragraph memberParagraph = section.AddParagraph();
                    memberParagraph.AddFormattedText("\n");
                    memberParagraph.AddFormattedText(m.firstName + " " + m.lastName + ": " + "total improved: " + m.getTotalImproved() + " total PR: " + m.totalPr, TextFormat.Bold);
                    memberParagraph.AddFormattedText("\n");
                    Paragraph recordsParagraph = section.AddParagraph();
                    recordsParagraph.Format.LeftIndent = "0.5cm";
                    foreach (SwimStyle st in m.newRecords.Keys)
                    {
                        foreach (Record r in m.newRecords[st])
                        {
                            recordsParagraph.AddFormattedText(r.ToString());
                            recordsParagraph.AddFormattedText("\n");
                        }
                    }
                }

                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                string filename = "";
                if (addDate)
                {
                    filename = title + " " + fromDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " - " + tillDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + ".pdf";
                }
                else
                {
                    filename = title + ".pdf";
                }
                pdfRenderer.PdfDocument.Save(filename);
                Process.Start(filename);
            }
        }

        private void fromPicker_ValueChanged(object sender, EventArgs e)
        {
            fromDate = fromPicker.Value;
        }

        private void tillPicker_ValueChanged(object sender, EventArgs e)
        {
            tillDate = tillPicker.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (MDB)|*.MDB;";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                pathBox.Text = openFileDialog.FileName;
                filePath = openFileDialog.FileName;
            } 
        }

        private void pathBox_TextChanged(object sender, EventArgs e)
        {
            filePath = pathBox.Text;
        }

        private void titleBox_TextChanged(object sender, EventArgs e)
        {
            title = titleBox.Text;
        }

        private void addDateCheck_CheckedChanged(object sender, EventArgs e)
        {
            addDate = addDateCheck.Checked;
        }
    }
}
