#pragma checksum "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff96c60d14d254946bb349bc44c05021548a5779"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Store_CustomPizza), @"mvc.1.0.view", @"/Views/Store/CustomPizza.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\_ViewImports.cshtml"
using PizzaBox.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\_ViewImports.cshtml"
using PizzaBox.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
using PizzaBox.Domain.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff96c60d14d254946bb349bc44c05021548a5779", @"/Views/Store/CustomPizza.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cd13274bc786c407551b2e3679ad230e4077f44", @"/Views/_ViewImports.cshtml")]
    public class Views_Store_CustomPizza : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PizzaBox.Web.Models.CustomPizzaViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Confirmation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
  
    ViewData["Title"] = "Custom";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Create your own pizza</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff96c60d14d254946bb349bc44c05021548a57794859", async() => {
                WriteLiteral("\r\n    <fieldset>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff96c60d14d254946bb349bc44c05021548a57795143", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 13 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <legend>Crust</legend>\r\n");
#nullable restore
#line 15 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
         foreach (var item in ViewBag.crusts as IList<Crust>)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
       Write(Html.RadioButtonFor(m => m.SelectedCrustId, item.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
                                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n");
#nullable restore
#line 18 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <legend>Cheese</legend>\r\n");
#nullable restore
#line 21 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
         foreach (var item in ViewBag.cheeses as IList<Cheese>)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
       Write(Html.RadioButtonFor(m => m.SelectedCheeseId, item.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
                                                                    Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n");
#nullable restore
#line 24 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <legend>Sauce</legend>\r\n");
#nullable restore
#line 27 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
         foreach (var item in ViewBag.sauces as IList<Sauce>)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
       Write(Html.RadioButtonFor(m => m.SelectedSauceId, item.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
                                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n");
#nullable restore
#line 30 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <legend>Size</legend>\r\n");
#nullable restore
#line 33 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
         foreach (var item in ViewBag.sizes as IList<Size>)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
       Write(Html.RadioButtonFor(m => m.SelectedSizeId, item.SizeId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
                                                                      Write(item.SizeName);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n");
#nullable restore
#line 36 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <legend>Topping</legend>\r\n");
#nullable restore
#line 39 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
         foreach (var item in ViewBag.toppings as IList<Toppings>)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
       Write(Html.RadioButtonFor(m => m.SelectedToppingId, item.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
                                                                     Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n");
#nullable restore
#line 42 "C:\P1\P1-Steven-Alvarez\PizzaBox\PizzaBox.Web\Views\Store\CustomPizza.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <input type=\"submit\" value=\"submit\" class=\"btn btn-primary\">\r\n    </fieldset>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PizzaBox.Web.Models.CustomPizzaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
