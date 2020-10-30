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
            string[] parts = line.Split(';');
            return new ChessPLayer()
            {
                Id = int.Parse(parts[0]),
                LastName = parts[1].Split(',')[0].Trim(),
                FirstName = parts[1].Split(',')[1].Trim(),
                Counrty = parts[3],
                Rating = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6])

            };
        }
    }
}
