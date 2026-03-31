namespace Week_4_Assessment
{
    class Patient
    {
        List<Patient> patients = new List<Patient>();
        public string Name { get; set; }
        public decimal BaseFee { get; set; }

        public virtual decimal CalculateBill()
        {
            return BaseFee;
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }

        public decimal CalculateTotalReveneue()
        {
            decimal sum = 0;
            foreach (var patient in patients)
            {
                sum += patient.CalculateBill();
            }
            return sum;
        }

        public int GetInpatientCount()
        {
            int count = 0;
            foreach (var v in patients)
            {
                if (v is Inpatient)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            return $"PatientName - {Name} TotalBill - {CalculateBill()}";
        }
    }

    class Inpatient : Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }

        public override decimal CalculateBill()
        {
            decimal total = 0;
            total += BaseFee + (DaysStayed * DailyRate);
            return total;
        }

        public override string ToString()
        {
            return $"PatientName - {Name} TotalBill - {CalculateBill()}";
        }
    }

    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }
        public override decimal CalculateBill()
        {
            decimal total = 0;
            total += BaseFee + ProcedureFee;
            return total;
        }

        public override string ToString()
        {
            return $"PatientName - {Name} TotalBill - {CalculateBill()}";
        }
    }

    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }

        public override decimal CalculateBill()
        {
            decimal total = 0;
            if (SeverityLevel <= 5 && SeverityLevel >= 1)
            {
                total += BaseFee * SeverityLevel;
            }
            return total;
        }

        public override string ToString()
        {
            return $"PatientName - {Name} TotalBill - {CalculateBill()}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Patient> p = new List<Patient>();
            {
                p.Add(new Patient()
                {
                    Name = "Raj",
                    BaseFee = 10000
                });

                p.Add(new Inpatient()
                {
                    Name = "Lucky",
                    BaseFee = 10000,
                    DaysStayed = 2,
                    DailyRate = 5000
                });
                p.Add(new Inpatient()
                {
                    Name = "Rohan",
                    BaseFee = 10000,
                    DaysStayed = 3,
                    DailyRate = 5000
                });

                p.Add(new Outpatient()
                {
                    Name = "Manish",
                    BaseFee = 10000,
                    ProcedureFee = 7000
                });

                p.Add(new EmergencyPatient()
                {
                    Name = "Kartik",
                    BaseFee = 10000,
                    SeverityLevel = 4
                });
            }
            foreach (Patient pat in p)
            {
                Console.WriteLine(pat);
            }

            Patient p1 = new Patient(); 
            foreach (Patient pat in p)
            {
                p1.AddPatient(pat);
            }
            Console.WriteLine("The total Revenue is : " + p1.CalculateTotalReveneue());
            Console.WriteLine("Inpatient count is : " + p1.GetInpatientCount());
        }
    }
}
