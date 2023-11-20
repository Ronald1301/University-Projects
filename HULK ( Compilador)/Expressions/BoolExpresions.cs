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


        public override Token.DataType CheckSemantic()
        {
            if (left.CheckSemantic() == Token.DataType.number && right.CheckSemantic() == Token.DataType.number)
            {
                return Token.DataType.number;
            }
            Error error = new TypeError(ErrorCode.SemanticError, "The expression is not of type boolean");
            App.Error(error.Text());
            return Token.DataType.error;
        }

        public override object Evaluate()
        {
            double a = Convert.ToDouble(left.Evaluate());
            double b = Convert.ToDouble(right.Evaluate());
            if (Convert.ToBoolean(this.comparison))
            {
                switch (this.comparison)
                {
                    case OperatorsComparison.DoubleEqual:
                        return a == b;
                    case OperatorsComparison.Less:
                        return a < b;
                    case OperatorsComparison.LessOrEqual:
                        return a <= b;
                    case OperatorsComparison.More:
                        return a > b;
                    case OperatorsComparison.MoreOrEqual:
                        return a >= b;
                    //case OperatorsComparison.NoEqual:
                    default:
                        return a != b;
                }
            }
            
            switch (this.logic)
            {
                case OperatorsLogic.And:
                    return (Convert.ToBoolean(a) == true) && (Convert.ToBoolean(b) == true) ? true : false;
                default:
                    return (Convert.ToBoolean(a) == true) || (Convert.ToBoolean(b) == true) ? true : false;
            }

        }
    }
}
