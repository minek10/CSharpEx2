using Microsoft.AspNetCore.Components;

namespace DemoApp.UI.Shared.Component
{
    public partial class BtnAdd
    {
        [Parameter]
        public string AddLink { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        #region Add
        protected void Add()
        {
            NavigationManager.NavigateTo($"{AddLink}");
        }

        #endregion        
        
    }
}
