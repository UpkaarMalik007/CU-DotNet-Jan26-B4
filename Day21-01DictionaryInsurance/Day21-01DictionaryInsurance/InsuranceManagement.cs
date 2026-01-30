using System.Diagnostics;

namespace Day21_01DictionaryInsurance
{
    class Policy
    {
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }   // 1–100
        public DateTime RenewalDate { get; set; }

        public override string ToString()
        {
            return $"Holder: {HolderName}, Premium: {Premium:C}, RiskScore: {RiskScore}, Renewal: {RenewalDate:d}";
        }
    }

    class PolicyTracker
    {
        private Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

        public void AddPolicy(string policyId, Policy policy)
        {
            policies[policyId] = policy;
        }


        public void ApplyBulkAdjustment()
        {
            foreach (var policy in policies.Values)
            {
                if (policy.RiskScore > 75)
                {
                    policy.Premium = policy.Premium * 1.05m;
                }
            }
        }

        public void CleanupOldPolicies()
        {
            List<string> policiesToRemove = new List<string>();
            DateTime cutoffDate = DateTime.Now.AddYears(-3);

            foreach (var item in policies)
            {
                if (item.Value.RenewalDate < cutoffDate)
                {
                    policiesToRemove.Add(item.Key);
                }
            }

            foreach (string key in policiesToRemove)
            {
                policies.Remove(key);
            }
        }

        public string GetPolicyById(string policyId)
        {
            Policy policy;
            if (policies.TryGetValue(policyId, out policy))
            {
                return policy.ToString();
            }
            else
            {
                return "Policy Not Found";
            }
        }
        public void DisplayAllPolicies()
        {
            foreach (var item in policies)
            {
                Console.WriteLine($"Policy ID: {item.Key} | {item.Value}");
            }
        }
    }
    internal class InsuranceManagement
    {
        static void Main(string[] args)
        {
            PolicyTracker tracker = new PolicyTracker();
            tracker.AddPolicy("P101", new Policy
            {
                HolderName = "Krish",
                Premium = 1850.75m,
                RiskScore = 82,
                RenewalDate = new DateTime(2023, 6, 15)
            });


            tracker.AddPolicy("P102 ", new Policy
            {
                HolderName = "Lochan",
                Premium = 1325.40m,
                RiskScore = 68,
                RenewalDate = new DateTime(2020, 3, 10)   // Old policy → cleanup
            });

            Console.WriteLine("Before bulk adjustment");
            tracker.DisplayAllPolicies();

            tracker.ApplyBulkAdjustment();

            Console.WriteLine("After bulk adjustment");
            tracker.DisplayAllPolicies();

            tracker.CleanupOldPolicies();

            Console.WriteLine("After cleanup");
            tracker.DisplayAllPolicies();

            Console.WriteLine("Search result");
            Console.WriteLine(tracker.GetPolicyById("PO101"));
            Console.WriteLine(tracker.GetPolicyById("PO102"));
        }
    }
}
