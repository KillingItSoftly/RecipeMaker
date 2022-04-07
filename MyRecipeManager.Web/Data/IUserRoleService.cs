namespace MyRecipeManager.Web.Data
{
    public interface IUserRoleService
    {
        Task EnsureAdminUserRole();
    }
}
