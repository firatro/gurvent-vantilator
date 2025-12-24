public interface IProductTestDataPointRepository
{
  Task<List<int>> GetProductIdsByAirFlowAsync(
    double airFlow,
    double tolerance,
    int[] qIndexes);

  Task<List<int>> GetProductIdsByAirFlowAndPressureAsync(
      double airFlow,
      double totalPressure,
      double toleranceQ,
      double tolerancePt,
      int[] qIndexes);

}
