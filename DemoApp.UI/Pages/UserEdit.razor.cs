using DemoApp.Data.Model;
using DemoApp.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DemoApp.UI.Pages
{
    public partial class UserEdit
    {
        [Inject] IUserService UserService { get; set; }
        [Inject] protected Sotsera.Blazor.Toaster.IToaster Toaster { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Parameter] public string Id { get; set; }
        public User Item { get; set; } = new();
        private bool _isLoading { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            await LoadItem();
            _isLoading = false;
        }

        #region LoadItem
        protected async Task LoadItem()
        {
            try
            {
                if (!String.IsNullOrEmpty(Id))
                {
                    Item = await UserService.GetById(Guid.Parse(Id));
                }
            }
            catch (Exception e)
            {
                NavigationManager.NavigateTo("/");
                Console.WriteLine(e);
                throw;
            }
        }
        #endregion

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) //Post
            {
                var res = await UserService.Add(Item);

                if (res.IsSuccessStatusCode)
                {
                    Toaster.Success("Utilisateur/trice ajouté(e)");
                    Item = new();
                }
                else
                {
                    Toaster.Warning("Erreur pendant l'ajout");
                }
            }
            else // Put
            {
                var res = await UserService.Update(Item);

                if (res.IsSuccessStatusCode)
                {
                    Toaster.Info("Utilisateur/trice modifié(e)");
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    Toaster.Warning("Erreur pendant la modification");
                }
            }
        }
    }
}
