using System;
namespace GradeCalculator
{
    public class Grade
    {
        public Grade(string Input)
        {
            if (String.IsNullOrEmpty(Input)
                || String.IsNullOrWhiteSpace(Input))
            {
                throw new FormatException("Failed to parse input");
            }

            string[] InputEx = Input.Split('/');

            if (String.IsNullOrWhiteSpace(InputEx[0])
                || String.IsNullOrWhiteSpace(InputEx[1]))
            {
                throw new FormatException("Failed to parse input");
            }

            this.Total = Decimal.Parse(InputEx[1].Trim());

            if (InputEx[0].Contains("%"))
            {
                // They input a percentage, convert it to a score
                this.Percentage = (Decimal.Parse(InputEx[0].Trim().Replace("%", String.Empty))) / 100;
                this.Score = this.Percentage * this.Total;
            }
            else
            {
                this.Score = Decimal.Parse(InputEx[0].Trim());
                this.Percentage = this.Score / this.Total;
            }
        }

        public decimal Score { get; set; }
        public decimal Total { get; set; }
        public decimal Percentage { get; set; }
    }
}
