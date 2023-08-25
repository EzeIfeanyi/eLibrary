namespace eLibrary.Services.IServices
{
    public interface IMessanger
    {
        string Send(string Subject, string UserEmail, string Body, string AttachmentPath);
    }
}
