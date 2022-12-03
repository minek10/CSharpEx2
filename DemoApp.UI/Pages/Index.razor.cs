using DemoApp.Data.Enum;
using DemoApp.Data.Model;
using DemoApp.Services;
using DemoApp.Services.Interfaces;
using DemoApp.UI.VM;
using Microsoft.AspNetCore.Components;

namespace DemoApp.UI.Pages
{
    public partial class Index
    {
        [Inject] IUserService UserService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] protected Sotsera.Blazor.Toaster.IToaster Toaster { get; set; }

        private List<User> Users { get; set; } = new();
        private List<User> UsersCopy { get; set; } = new();
        private List<string> Filters { get; set; } = Enum.GetValues(typeof(KindOfFilter)).Cast<KindOfFilter>().Select(v => v.ToString()).ToList();
        private string _message = "Aucun élément";
        private Filter FilterSearch { get; set; } = new();
        private bool _isLoading { get; set; } = false;
        private bool orderAscending = true;
        private bool _isDeleteDialogOpen { get; set; }
        private Guid _id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _isLoading = true;
                await LoadList();
                _isLoading = false;
                StateHasChanged();
            }
            catch(Exception e)
            {
                Toaster.Warning("Page inaccessible");
                Console.WriteLine(e);
                throw;
            }
        }

        #region LoadList
        protected async Task LoadList()
        {
            Users = (await UserService.GetUsersFilter(string.Empty, 0)).ToList();
            UsersCopy = Users;
            FilterSearch = new();
            StateHasChanged();
        }
        #endregion

        #region OrderBy
        protected void SortBy(string type)
        {
            orderAscending = !orderAscending;

            if (orderAscending)
            {
                switch (type)
                {
                    case "lastname":
                        Users = Users.OrderBy(c => c.LastName).ToList();
                        break;
                    case "firstname":
                        Users = Users.OrderBy(c => c.FirstName).ToList();
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case "lastname":
                        Users = Users.OrderByDescending(c => c.LastName).ToList();
                        break;
                    case "firstname":
                        Users = Users.OrderByDescending(c => c.FirstName).ToList();
                        break;
                }
            }
            StateHasChanged();
        }
        #endregion

        #region Filter
        protected void Filter()
        {
            if (!string.IsNullOrEmpty(FilterSearch.Name))
            {
                string filter = FilterSearch.Name.ToUpper();

                switch (FilterSearch.KOF)
                {
                    case KindOfFilter.Nom: 
                        Users =  UsersCopy.Where(x => x.DeleteDate == null && x.FirstName.ToUpper().Contains(filter)).ToList();
                        break;
                    case KindOfFilter.Prenom:
                        Users = UsersCopy.Where(x => x.DeleteDate == null && x.LastName.ToUpper().Contains(filter)).ToList();
                        break;
                    default: Users = UsersCopy;
                        break;
                }
                StateHasChanged();
            }
        }
        #endregion

        #region Delete
        protected async void Delete(bool accepted)
        {
            if (accepted)
            {
                Guid userid = Guid.Parse("bf80287a-b043-438b-acaf-f6208361deb0");

                var res = await UserService.Delete(_id, userid);
                if (res.IsSuccessStatusCode)
                {
                    Toaster.Success("Utilisateur supprimé");
                    await LoadList();
                }
                else
                {
                    Toaster.Warning("L'utilisateur n'a pas été supprimée");
                }
            }

            _isDeleteDialogOpen = false;
            StateHasChanged();
        }
        #endregion

        #region ShowDeleteModal
        private void OpenDeleteDialog(Guid id)
        {
            _id = id;
            _isDeleteDialogOpen = true;
            StateHasChanged();
        }
        #endregion

    }


}
