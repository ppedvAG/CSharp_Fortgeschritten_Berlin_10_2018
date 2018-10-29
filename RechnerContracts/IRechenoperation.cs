namespace RechnerContracts
{
    public interface IRechenoperation
    {
        char Rechensymbol { get; }
        double Berechne(IFormel formel);
    }
}