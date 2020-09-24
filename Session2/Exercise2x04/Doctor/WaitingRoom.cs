using System;
using System.Threading;

public class WaitingRoom
{
	public Action<int> NumberChange;
	private int _currentNumber;
	private int _ticketCount;
	public WaitingRoom()
	{
		_currentNumber = 0;
		_ticketCount = 0;
	}
	public void RunWaitingRoom()
    {
		while(_currentNumber<_ticketCount)
        {
			_currentNumber++;
			Console.WriteLine("Diing!");
			NumberChange?.Invoke(_currentNumber);
			Thread.Sleep(1000);
        }
    }
	public int DrawNumber() => ++_ticketCount;
}
