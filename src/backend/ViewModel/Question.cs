public class QuestionViewModel
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public string Type { get; set; }
    public string[] Options { get; set; }
    public int CorrectOption { get; set; }
}