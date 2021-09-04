using BuyMe.Application.Common.Exceptions;

namespace BuyMe.Application.Common.Behaviour
{
    /// <summary>
    /// Simple interface to provide a generic mechanism to build guard clause extension methods from.
    /// </summary>
    public interface IGuardClause
    {
    }

    /// <summary>
    /// An entry point to a set of Guard Clauses defined as extension methods on IGuardClause.
    /// </summary>
    public class Guard : IGuardClause
    {
        /// <summary>
        /// An entry point to a set of Guard Clauses.
        /// </summary>
        public static IGuardClause Against { get; } = new Guard();

        private Guard()
        {
        }
    }

    /// <summary>
    /// A collection of common guard clauses, implemented as extensions.
    /// </summary>
    /// <example>
    /// Guard.Against.Null(input, nameof(input));
    /// </example>
    public static class GuardClauseExtensions
    {
        public static T Null<T>(this IGuardClause guardClause, T input, object parameterName)
        {
            if (input is null) throw new NotFoundException(typeof(T).Name, parameterName);

            return input;
        }
    }
}