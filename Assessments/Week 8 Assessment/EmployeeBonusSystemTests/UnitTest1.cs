
using EmployeeBonusSystem;
namespace EmployeeBonusSystemTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Normal_High_Performer_Test()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 500000,
                PerformanceRating = 5,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.1m,
                AttendancePercentage = 95
            };

            Assert.AreEqual(123200.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void AttendancePenalty_Applied()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 400000,
                PerformanceRating = 4,
                YearsOfExperience = 8,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 80 // <85% triggers penalty
            };

            Assert.AreEqual(60480.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void CapTriggered_BonusCapped()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 1000000,
                PerformanceRating = 5,
                YearsOfExperience = 15,
                DepartmentMultiplier = 1.5m,
                AttendancePercentage = 95
            };

            Assert.AreEqual(280000.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void ZeroSalary_ReturnsZero()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 0,
                PerformanceRating = 5
            };

            Assert.AreEqual(0.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void LowPerformer_Rating2()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 300000,
                PerformanceRating = 2,
                YearsOfExperience = 3,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 90
            };

            Assert.AreEqual(13500.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TaxBoundary_150k()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 600000,
                PerformanceRating = 3,
                YearsOfExperience = 0,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 100
            };

            Assert.AreEqual(64800.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void HighTaxSlab_Above300k()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 900000,
                PerformanceRating = 5,
                YearsOfExperience = 11,
                DepartmentMultiplier = 1.2m,
                AttendancePercentage = 100
            };

            Assert.AreEqual(226800.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void RoundingPrecision_Test()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 555555,
                PerformanceRating = 4,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.13m,
                AttendancePercentage = 92
            };

            Assert.AreEqual(118649.88m, emp.NetAnnualBonus);
        }
    }
}