using Microsoft.AspNetCore.Components;

namespace SimpleChatWASM.Client.Models.Services
{
    public interface IScroll
    {
        ValueTask Init();
        ValueTask ScrollBottom(ElementReference canvas);
    }
}
