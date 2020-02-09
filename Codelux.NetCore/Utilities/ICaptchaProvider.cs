using System.Drawing;

namespace Codelux.NetCore.Utilities
{
    public interface ICaptchaProvider
    {
        string CaptchaText { get; }
        Bitmap CreateCaptchaImage();
    }
}
