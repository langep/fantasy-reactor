using System.Collections.Generic;
using JetBrains.Annotations;

namespace FR.Tools.Grids
{
    public interface IGrid<in TCoords, TCell>
    {

        /// <summary>
        /// Checks if given coordinates are valid in grid.
        /// <para> Validity of coordinates depends on the implementation e.g. out-of-bounds coordinates in a fixed size grid.</para>
        /// </summary>
        /// <param name="coords">The coordinates to check.</param>
        /// <returns>`true` if the coords are valid coordinates for the grid; `false` otherwise.</returns>
        bool IsValidCoord([NotNull] TCoords coords);

        /// <summary>
        /// Attempts to add the cell to the grid.
        /// </summary>
        /// <param name="coords">The coordinates where the cell will be added.</param>
        /// <param name="cell">The cell to add.</param>
        /// <param name="existsOk">if `true` overwrite existing cell at given coords; fails to add otherwise</param>
        /// <returns>`true` if the cell was added; `false` otherwise</returns>
        bool TryAddCell([NotNull] TCoords coords, TCell cell, bool existsOk = true);

        /// <summary>
        /// Attempts to get the cell at given coordinates.
        /// </summary>
        /// <param name="coords">The coordinates of the desired cell</param>
        /// <param name="cell">The cell.</param>
        /// <returns>`true` if the cell was retrieved successfully, `false` otherwise</returns>
        bool TryGetCell([NotNull] TCoords coords, out TCell cell);
    }
}