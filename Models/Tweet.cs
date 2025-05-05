namespace Relations.Models;

public class Tweet
{
    public string Content { get; set; } // content = içerik
    public User User { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; // ön tanımlı değer
}