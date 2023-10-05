namespace eShop.API.Dtos
{
    public record AuthResult
    {
        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
