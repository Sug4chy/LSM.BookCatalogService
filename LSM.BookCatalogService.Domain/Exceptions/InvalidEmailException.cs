namespace LSM.BookCatalogService.Domain.Exceptions;

public class InvalidEmailException(string message) : Exception(message);