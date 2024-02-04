namespace HuzlabBlog.Service.Services.Abstractions
{
    public interface ITranslationService
    {
        Task<string> TranslateAsync(string text, string targetLanguage);
    }
}
