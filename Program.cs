using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace fileParser
{
    public class Program
    {
        private const string fileInPath = "c:/csvFiles/In";
        private const string fileOutPath = "c:/csvFiles/Out";

        public static void Main(string[] args)
        {
            foreach (var file in Directory.GetFiles(fileInPath))
            {
                var members = ParseCSV(file);
                var insuranceProviders = members.Select(x => x.Insurance).Distinct();
                foreach (var provider in insuranceProviders)
                {

                    var specificMembers = members.Where(x => x.Insurance == provider);

                    specificMembers = specificMembers.OrderByDescending(x => x.Name);
                    specificMembers = specificMembers.GroupBy(x => x.Name).Select(y => y.Max());
                    File.WriteAllText(($"{fileOutPath}_Provider{provider}_{DateTime.Now}"), string.Join(",", specificMembers));
                }
            }
        }
        public static List<Member> ParseCSV(string filePath)
        {
            var memberList = new List<Member>();

            var lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                var content = line.Split(",");
                memberList.Add(new Member
                {
                    UserId = content[0],
                    Name = content[1],
                    VersionNumber = Convert.ToInt32(content[2]),
                    Insurance = content[3]
                });

            }
            return memberList;

        }
    }
}
