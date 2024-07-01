using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure.Design;
using System.Windows;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.Repository;

namespace PetCenter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var repo = new AccountSqlRepository(new DataContext());

            repo.GetAll();

            base.OnStartup(e);
        }
    }

}
