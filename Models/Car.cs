class Car
{
    public IEngine _engine;

    public Car(IEngine engine)
    {
        _engine = engine;
        _engine.startTheCar();
    }
}