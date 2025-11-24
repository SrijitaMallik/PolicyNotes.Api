namespace PolicyNotes.Api.DTOs
{
    public class NoteCreateDto
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
