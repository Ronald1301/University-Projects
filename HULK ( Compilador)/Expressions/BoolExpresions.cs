namespace Hulk
{
    public class BoolExpresions : Expressions
    {
        public enum OperatorsComparison
        {
            Less, More, LessOrEqual, MoreOrEqual, DoubleEqual, NoEqual,

        }
        public enum OperatorsLogic
        {
            And, Or,
        }

        public Expressions left;
        public Expressions right;
        OperatorsComparison comparison;
        OperatorsLogic logic;

        public BoolExpresions(Expressions left, Expressions right, OperatorsComparison comparison)
        {
            this.left = left;
            this.right = right;
            this.comparison = comparison;
        }
        public BoolExpresions(Expressions left, Expressions right, OperatorsLogic logic)
        {
            this.left = left;
            this.right = right;
            this.logic = logic;
        }


        public override bool CheckSemantic()
        {
            throw new Exception();
        }

        public override double Evaluate()
        {
            double a = left.Evaluate();
            double b = right.Evaluate();
            switch (this.comparison)
            {
                case OperatorsComparison.DoubleEqual:
                    return a == b ? 1 : 0;
                case OperatorsComparison.Less:
                    return a < b ? 1 : 0;
                case OperatorsComparison.LessOrEqual:
                    return a <= b ? 1 : 0;
                case OperatorsComparison.More:
                    return a > b ? 1 : 0;
                case OperatorsComparison.MoreOrEqual:
                    return a >= b ? 1 : 0;
                case OperatorsComparison.NoEqual:
                    return a != b ? 1 : 0;
                default:
                    switch (this.logic)
                    {
                        case OperatorsLogic.And:
                            return (Convert.ToBoolean(a) == true) && (Convert.ToBoolean(b) == true) ? 1 : 0;
                        default:
                            return (Convert.ToBoolean(a) == true) || (Convert.ToBoolean(b) == true) ? 1 : 0;
                    }

            }
        }
    }
}
