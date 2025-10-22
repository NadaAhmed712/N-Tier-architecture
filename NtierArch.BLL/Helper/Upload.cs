namespace NtierArch.BLL.Helper
{
    public static class Upload
    {
        public static string UploadFile(string FolderName, IFormFile File)
        {
            try
            {
                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);
                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);
                string FilePath = Path.Combine(FolderPath, FileName);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    File.CopyTo(stream);
                }
                return FileName;
            }
            catch(Exception ex)
            {
                return null;
            }

        }
        public static string RemoveFile(string FolderName, string FileName)
        {
            try
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName, FileName);
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return "File Deleted Successfully";
                }
                else
                {
                    return "File Not Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
