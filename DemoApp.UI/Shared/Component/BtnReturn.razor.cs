using Microsoft.AspNetCore.Components;

namespace DemoApp.UI.Shared.Component
{
    public partial class BtnReturn
    {
        [Parameter]
        public string AddLink { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected void Return()
        {
            NavigationManager.NavigateTo($"{AddLink}");
        }      
    }
}
