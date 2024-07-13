using LSM.BookCatalogService.Domain.Exceptions;

namespace LSM.BookCatalogService.Domain.ValueObjects;

public class Isbn
{
    public int CountryCode { get; }
    public int PublisherCode { get; }
    public int UniqueBookCode { get; }

    public Isbn(int countryCode, int publisherCode, int uniqueBookCode, bool isRussian = false)
    {
        if (isRussian)
        {
            if (publisherCode.ToString().Length + uniqueBookCode.ToString().Length != 8)
            {
                throw new InvalidRussianIsbnPartsException(
                    "Сумма цифр у кода издательства и кода издания у " +
                    "российских экземпляров должна составлять 8 цифр!"
                );
            }
        }

        CountryCode = countryCode;
        PublisherCode = publisherCode;
        UniqueBookCode = uniqueBookCode;
    }

    public int ControlDigit => CalculateControlDigit();

    public override string ToString()
    {
        return $"{CountryCode}-{PublisherCode}-{UniqueBookCode}-{ControlDigit}";
    }

    private int CalculateControlDigit()
    {
        string isbnWithoutControlDigit = $"{CountryCode}{PublisherCode}{UniqueBookCode}";
        int sum = 0;
        int i = 0;
        for (int j = 10; j > 1; j--)
        {
            sum += (isbnWithoutControlDigit[i] - '0') * j;
            i++;
        }

        return 11 - sum % 11;
    }
}