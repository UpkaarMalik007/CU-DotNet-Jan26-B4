namespace BackendAPI.Execeptions
{
    public class DestinationNotFoundException:Exception
    {
        public DestinationNotFoundException(int id)
            : base($"Destination with ID {id} was not found.")
        {
        }
    }
}
