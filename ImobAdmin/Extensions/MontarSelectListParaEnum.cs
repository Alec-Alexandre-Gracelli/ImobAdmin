using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ImobAdmin.Extensions
{
    public static class ControllerEnumsExtensions
    {
        public static List<SelectListItem> MontarSelectListParaEnum<T>(this Controller controller, T selected = default(T), bool excludeDefault = false) where T : struct, IConvertible
        {
            var excludeCallback = default(Func<T, bool>);
            if (excludeDefault)
            {
                excludeCallback = (enumerador) => enumerador.Equals(default(T));
            }
            return controller.MontarSelectListParaEnum(selected, excludeCallback);
        }

        public static List<SelectListItem> MontarSelectListParaEnum<T>(this Controller controller, T selected, Func<T, bool> excludeCallback) where T : struct, IConvertible
        {
            var items = new List<SelectListItem>();
            var enums = Enum.GetValues(typeof(T)).Cast<T>();
            foreach (var enumerador in enums.OrderBy(o => o.GetDisplayName()))
            {
                if (excludeCallback != default && excludeCallback(enumerador))
                    continue;
                var name = enumerador.GetDisplayName();
                var item = new SelectListItem()
                {
                    Value = enumerador.ToString(),
                    Text = name,
                    Selected = selected.Equals(enumerador)
                };
                items.Add(item);
            }
            return items;
        }


    }
}
