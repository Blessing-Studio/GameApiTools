namespace GameApiTools.Module.Enums;

public enum KnownReturnCode
{
    InternalFailure = int.MinValue,
    AlreadySignedIn = -5003,
    AuthKeyTimeOut = -101,
    OK = 0,
    NotDefined = 7,
    DataIsNotPublicForTheUser = 10102,
}