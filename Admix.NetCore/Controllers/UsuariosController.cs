using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Admix.NetCore.Models;
using Admix.NetCore.Repository.Generics;

namespace Admix.NetCore.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IRepository<ApplicationUser> _user;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuariosController(IRepository<ApplicationUser> user,
            UserManager<ApplicationUser> userManager,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _user = user;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        // GET
        public IActionResult Index(bool ativo, string nome, string email, int grupo)
        {
            var users = _user.FindAll();

            if (!string.IsNullOrWhiteSpace(nome))
                users = users.Where(u => u.NormalizedUserName.Contains(nome.ToUpper())).ToList();

            if (!string.IsNullOrWhiteSpace(email))
                users = users.Where(u => u.NormalizedEmail.Contains(email.ToUpper())).ToList();

            /*
            var usersViewModel = new ApplicationUserViewModel
            {
                Grupos =  new SelectList(GrupoUsuario)
            };
            */

            return View(users);
        }


        public async Task<IActionResult> Details(string id)
        {
            return View(await _userManager.FindByIdAsync(id));
        }

        public async Task<IActionResult> Edit(string id)
        {
            return View(await _userManager.FindByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (ModelState.IsValid)
            {
                user.Status = model.Status;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Grupo = model.Grupo;

                if (!string.IsNullOrWhiteSpace(model.Senha))
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.Senha);


                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded) throw new Exception();
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(string id)
        {
            return View(await _userManager.FindByIdAsync(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded) return RedirectToAction(nameof(Index));

            return View();
        }
    }
}