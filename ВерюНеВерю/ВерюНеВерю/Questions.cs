namespace ВерюНеВерю
{
    public class Questions
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Comment { get; set; }
        public static Questions CsvLineParse(string csvLine)
        {
            string[] parts = csvLine.Split(';');
            return new Questions
            {
                Number = int.Parse(parts[0]),
                Question = parts[1].Trim(),
                Answer = parts[2].Trim(),
                Comment = parts[3].Trim()
            };

        }

    }
}
