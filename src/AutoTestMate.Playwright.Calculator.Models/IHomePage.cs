using System.Threading.Tasks;

namespace AutoTestMate.Playwright.Calculator.Models
{
    public interface IHomePage
    {
        Task<HomePage> Open();
    }
}