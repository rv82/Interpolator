using ReactiveUI;
using System.Reactive;

namespace Interpolator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double x1, y1, x2, y2, x, y;
        private string ex2, ey2, ex, ey;

        public double X1 { get => x1; set => this.RaiseAndSetIfChanged(ref x1, value); }
        public double Y1 { get => y1; set => this.RaiseAndSetIfChanged(ref y1, value); }
        public double X2 { get => x2; set => this.RaiseAndSetIfChanged(ref x2, value); }
        public double Y2 { get => y2; set => this.RaiseAndSetIfChanged(ref y2, value); }
        public double X { get => x; set => this.RaiseAndSetIfChanged(ref x, value); }
        public double Y { get => y; set => this.RaiseAndSetIfChanged(ref y, value); }

        public string ErrorX2 { get => ex2; set => this.RaiseAndSetIfChanged(ref ex2, value); }
        public string ErrorY2 { get => ey2; set => this.RaiseAndSetIfChanged(ref ey2, value); }
        public string ErrorX { get => ex; set => this.RaiseAndSetIfChanged(ref ex, value); }

        public MainWindowViewModel()
        {
            DoClear = ReactiveCommand.Create(Clear);
            DoCalculate = ReactiveCommand.Create(Calculate);
        }

        public ReactiveCommand<Unit, Unit> DoClear { get; }
        public ReactiveCommand<Unit, Unit> DoCalculate { get; }

        public void Clear()
        {
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
            X = 0;
            Y = 0;
            ErrorX = string.Empty;
            ErrorX2 = string.Empty;
            ErrorY2 = string.Empty;
        }

        public void Calculate()
        {
            ErrorX2 = Check(X1, X2, "X1 >= X2");
            ErrorY2 = Check(Y1, Y2, "Y1 >= Y2");
            ErrorX = Check(X1, X, "X1 >= X");
            ErrorX = Check(X, X2, "X >= X2");

            Y = (Y2 - Y1) * (X - X1) / (X2 - X1) + Y1;
        }

        private string Check(double value1, double value2, string errorMessage)
        {
            return value2 <= value1 ? errorMessage : string.Empty;
        }
    }
}