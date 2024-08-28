using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SimpleChatWASM.Client.Models.Services
{
    public class Scroll:IScroll
    {
        private readonly IJSRuntime _js;
        private IJSObjectReference? _module;

        public Scroll(IJSRuntime js)
            => _js = js;

        public async ValueTask Init()
            => _module = _module ?? await _js.InvokeAsync<IJSObjectReference>
            ("import", "./js/Scroll.js");


        public async ValueTask ScrollBottom(ElementReference element)
            => await _module!.InvokeVoidAsync("ScrollBottom", element);
    }
}
