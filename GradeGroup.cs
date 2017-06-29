using System;
using System.Collections.Generic;

namespace GradeCalculator
{
    public class GradeGroup
    {
        public GradeGroup(string InName, string InWeight)
        {
            this.Name = InName.Trim();

            try
            {
                this.Weight = (Decimal.Parse(InWeight.Trim().Replace("%", String.Empty))) / 100;
            }
            catch (Exception e)
            {
                throw new FormatException("Failed to parse input", e);
            }
        }

        public string Name { get; set; }
        public decimal Weight { get; set; }
        public List<Grade> Grades { get; set; }
    }
}