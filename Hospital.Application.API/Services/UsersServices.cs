using Hospital.Application.API.Data.Repository.Interface;
using Hospital.Application.API.Extensions;
using Hospital.Application.API.Model;
using Hospital.Application.API.Services.Interfaces;
using Microsoft.Extensions.Hosting.Internal;
using Serilog;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.Application.API.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            try
            {
                return await _usersRepository.GetUsersAllAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return null;
            }
        }

        public async Task<bool> SavePictureFile(FormFileModel formFile)
        {
            try
            {
                var diretorio = $"{Directory.GetCurrentDirectory()}/FilesPicture";
                string extensao = Path.GetExtension(formFile.file.FileName).ToUpper();

                var fileName = $"{formFile.UserId}{extensao}";

                string path = GetFilePath(fileName);



                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    //320a9652-55cd-431c-a5e4-3482646efa68
                    formFile.file.CopyTo(stream);
                }

                var resultRepository = await _usersRepository.SavePathImages(path, formFile.UserId);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return false;
            }
        }
        private string GetFilePath(string fileName)
        {
            var actualPath = Directory.GetCurrentDirectory();
            var parentPath = Directory.GetParent(actualPath + "\\FilesPicture\\").FullName;
            var path = Path.Combine(parentPath, fileName);
            //var path = @"C:\inetpub\sites\skydigital.appindigo.com.br\wwwroot\static\mock-images\avatars\" + fileName;

            return path;
        }

        public async Task<string> ReturnPictureProfile(string UserId)
        {
            try
            {
                var path = await _usersRepository.ReturnPathPicture(UserId);

                var contents = System.IO.File.ReadAllBytes(path);
                return Convert.ToBase64String(contents);
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return null;
            }
        }
    }
}
