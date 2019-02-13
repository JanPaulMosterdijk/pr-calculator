using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_calculator.models
{
    class Member
    {
        public int id;
        public string firstName;
        public string lastName;
        DateTime birthDate;
        int registrationId;
        Gender gender;
        public Dictionary<SwimStyle, Record> records;
        public Dictionary<SwimStyle, List<Record>> newRecords;
        TimeSpan totalImproved;
        public List<Result> results;
        public int totalPr = 0;

        public Member(int id, string firstName, string lastName, DateTime birthDate, int registrationId, Gender gender) {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.registrationId = registrationId;
            this.gender = gender;
            this.records = new Dictionary<SwimStyle, Record>();
            this.newRecords = new Dictionary<SwimStyle, List<Record>>();
            this.results = new List<Result>();
            totalImproved = new TimeSpan();
        }

        public string getTotalImproved() {
            return totalImproved.ToString(@"hh\:mm\:ss\:ff").Replace("00:0", "0").Replace("00","0");
        }

        public void addRecord(Record record) {
            if (records.ContainsKey(record.swimStyle))
            {
                records[record.swimStyle] = record;
            }
            else {
                records.Add(record.swimStyle, record);
            }
        }

        public void addNewRecord(Record record)
        {
            if (newRecords.ContainsKey(record.swimStyle))
            {
                newRecords[record.swimStyle].Add(record);
            }
            else
            {
                newRecords.Add(record.swimStyle, new List<Record>() { record });
            }
            totalImproved = totalImproved.Add(record.differenceAsTimeSpan);
            totalPr++;
        }

        public override string ToString()
        {
            return firstName + " " + lastName; 
        }
    }
}
