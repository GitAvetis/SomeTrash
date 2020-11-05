namespace F_Delegation
{
    public class ChessPLayer
    {
        public string Counrty { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName + " " + LastName}, Rating = {Rating}, from {Counrty}, born in {BirthYear}";
        }

        public static ChessPLayer ParseFideCsv(string line)
        {
            while (line.Contains('"'))
            {
                line = line.Remove(line.IndexOf('"'),1);
            }
            string[] parts = line.Split(';');
            return new ChessPLayer()
            {
                Id = int.Parse(parts[0]),
                LastName = parts[1].Trim(),
                FirstName = parts[2].Trim(),
                Counrty = parts[4],
                Rating = int.Parse(parts[5]),
                BirthYear = int.Parse(parts[7])

            };
        }
    }
}
