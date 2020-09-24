
using System;

public class Patient
{
    private int _numberInQueue;
    private WaitingRoom _waitingRoom;
    public Patient(WaitingRoom wr)
    {
        _waitingRoom = wr;
        _numberInQueue = _waitingRoom.DrawNumber();
        Console.WriteLine($"Patient {_numberInQueue} enters the room");
        _waitingRoom.NumberChange += ReactToNumber;
    }

    public void ReactToNumber(int ticketNumber)
    {
        Console.WriteLine($"Patient {_numberInQueue} looks up.");
        string result = $"Patient {_numberInQueue} goes ";
        if (ticketNumber == _numberInQueue)
        {
            result += "to the doctor's office.";
            _waitingRoom.NumberChange -= ReactToNumber;
        }
        else
            result += "back to play with the phone.";
        Console.WriteLine(result);
    }
}
