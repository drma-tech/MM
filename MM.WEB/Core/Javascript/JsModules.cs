using Microsoft.JSInterop;

namespace MM.WEB.Core.Javascript
{
    public static class JsModules
    {
        public static WindowJs Window(this IJSRuntime js) => new(js);

        public static UtilsJs Utils(this IJSRuntime js) => new(js);

        public static SupabaseJs Supabase(this IJSRuntime js) => new(js);

        public static ServicesJs Services(this IJSRuntime js) => new(js);

        public static SliderJs Slider(this IJSRuntime js) => new(js);

        public static PaymentsJs Payments(this IJSRuntime js) => new(js);

        public static CropperJs Cropper(this IJSRuntime js) => new(js);
    }
}