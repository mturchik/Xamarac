using System;

namespace Xamarac.Services
{
    public enum SurveyResponse
    {
        Neutral = 0,
        StrongNegative = 1,
        Negative = 2,
        Positive = 4,
        StrongPositive = 5
    }

    public static class SurveyResponseExtensions
    {
        public static SurveyResponse IncreaseResponse(this SurveyResponse response)
        {
            switch (response)
            {
                case SurveyResponse.StrongNegative: return SurveyResponse.Negative;
                case SurveyResponse.Negative:       return SurveyResponse.Neutral;
                case SurveyResponse.Neutral:        return SurveyResponse.Positive;
                case SurveyResponse.Positive:       return SurveyResponse.StrongPositive;
                case SurveyResponse.StrongPositive: return SurveyResponse.StrongPositive;
                default:                            throw new ArgumentOutOfRangeException(nameof(response), response, null);
            }
        }

        public static SurveyResponse DecreaseResponse(this SurveyResponse response)
        {
            switch (response)
            {
                case SurveyResponse.StrongNegative: return SurveyResponse.StrongNegative;
                case SurveyResponse.Negative:       return SurveyResponse.StrongNegative;
                case SurveyResponse.Neutral:        return SurveyResponse.Negative;
                case SurveyResponse.Positive:       return SurveyResponse.Neutral;
                case SurveyResponse.StrongPositive: return SurveyResponse.Positive;
                default:                            throw new ArgumentOutOfRangeException(nameof(response), response, null);
            }
        }
    }
}