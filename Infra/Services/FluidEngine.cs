using Fluid;
using System.Threading.Tasks;
using System.IO;

namespace JsBridge.Infra.Services
{
    public static class FluidEngine
    {
        private static readonly FluidParser _parser = new FluidParser();

        public static async Task<string> RenderAsync(string file, object model)
        {
            if(!File.Exists(file))
            {
                return string.Empty;
            }
            var template = await File.ReadAllTextAsync(file);
            if(_parser.TryParse(template,out var result, out var error))
            {
                return await result.RenderAsync(new TemplateContext(model));
            }
            else
            {
                return string.Empty;
            }
        }

    }
}