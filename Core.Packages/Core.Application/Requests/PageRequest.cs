namespace Core.Application.Requests
{
    public class PageRequest
    {
        public PageRequest()
        {
        }

        public PageRequest(int size, int index)
        {
            Size = size;
            Index = index;
        }

        public int Size { get; set; } = 10;
        public int Index { get; set; } = 0;
    }
}
