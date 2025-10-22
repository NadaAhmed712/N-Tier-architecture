namespace NtierArch.BLL.ResponseResult
{
    public record Response<T>(T Result, string? ErrorMessage, bool IsHaveError);
}
