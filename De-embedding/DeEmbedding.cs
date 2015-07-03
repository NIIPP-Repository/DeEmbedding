using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using SDKMath;

namespace SDKDeEmbedding
{
    public class DeEmbedding
    {
        private string
            _pathToFileOpenPattern,
            _pathToFileShortPattern,
            _pathToFilePadPattern,
            _pathToFileLinePattern,
            _pathToFileTwoLinePattern,
            _currMethod;
        private string[]
            _pathesToFileDUTPattern;  // Device Under Test

        private Curve
            _fileOpenPattern,
            _fileShortPattern,
            _filePadPattern,
            _fileLinePattern,
            _fileTwoLinePattern;

        public DeEmbedding()
        {
            
        }

        public void OpenMethodDeEmbedding(string pathToFileOpenPattern, string[] pathesToFileDUTPattern, string pathToSaveFolder)
        {
            _pathesToFileDUTPattern = (string[]) pathesToFileDUTPattern.Clone();

            _pathToFileOpenPattern = pathToFileOpenPattern;
            _fileOpenPattern = new Curve(pathToFileOpenPattern);
            _fileOpenPattern.SetFormatOfPoints("RI");

            _currMethod = "open";

            CalcAndSaveResult(pathToSaveFolder);
        }

        public void L2LMethodDeEmbedding(string pathToFileLinePattern, string pathToFileTwoLinePattern, string[] pathesToFileDUTPattern, string pathToSaveFolder)
        {
            _pathesToFileDUTPattern = (string[])pathesToFileDUTPattern.Clone();

            _pathToFileLinePattern = pathToFileLinePattern;
            _pathToFileTwoLinePattern = pathToFileTwoLinePattern;

            _fileLinePattern = new Curve(pathToFileLinePattern);
            _fileTwoLinePattern = new Curve(pathToFileTwoLinePattern);
            _fileLinePattern.SetFormatOfPoints("RI");
            _fileTwoLinePattern.SetFormatOfPoints("RI");

            _currMethod = "l-2l";

            CalcAndSaveResult(pathToSaveFolder);
        }

        public void OpenShortMethodDeEmbedding(string pathToFileOpenPattern, string pathToFileShortPattern, string[] pathesToFileDUTPattern, string pathToSaveFolder)
        {
            _pathesToFileDUTPattern = (string[]) pathesToFileDUTPattern.Clone();

            _pathToFileOpenPattern = pathToFileOpenPattern;
            _pathToFileShortPattern = pathToFileShortPattern;

            _fileOpenPattern = new Curve(pathToFileOpenPattern);
            _fileShortPattern = new Curve(pathToFileShortPattern);
            _fileOpenPattern.SetFormatOfPoints("RI");
            _fileShortPattern.SetFormatOfPoints("RI");

            _currMethod = "open-short";

            CalcAndSaveResult(pathToSaveFolder);
        }

        public void PadOpenShortMethodDeEmbedding(string pathToFilePadPattern, string pathToFileOpenPattern, string pathToFileShortPattern, string[] pathesToFileDUTPattern, string pathToSaveFolder)
        {
            _pathesToFileDUTPattern = (string[])pathesToFileDUTPattern.Clone();

            _pathToFilePadPattern = pathToFilePadPattern;
            _pathToFileOpenPattern = pathToFileOpenPattern;
            _pathToFileShortPattern = pathToFileShortPattern;
            
            _filePadPattern = new Curve(pathToFilePadPattern);
            _fileOpenPattern = new Curve(pathToFileOpenPattern);
            _fileShortPattern = new Curve(pathToFileShortPattern);
            _filePadPattern.SetFormatOfPoints("RI");
            _fileOpenPattern.SetFormatOfPoints("RI");
            _fileShortPattern.SetFormatOfPoints("RI");

            _currMethod = "pad-open-short";

            CalcAndSaveResult(pathToSaveFolder);
        }

        private void CalcAndSaveResult(string pathToSaveFolder)
        {
            for (int n = 0; n < _pathesToFileDUTPattern.Length; n++)
            {
                Curve fileDUTPattern = new Curve(_pathesToFileDUTPattern[n]);
                fileDUTPattern.SetFormatOfPoints("RI");
                fileDUTPattern.AddNewComment("This is de-embedded s2p file");

                string newName = Path.GetFileNameWithoutExtension(_pathesToFileDUTPattern[n]) + "_deembedded" + Path.GetExtension(_pathesToFileDUTPattern[n]);

                switch (_currMethod)
                {
                    case "open": 
                        OpenMethod(ref fileDUTPattern); break;
                    case "l-2l": 
                        L2LMethod(ref fileDUTPattern); break;
                    case "open-short": 
                        OpenShortMethod(ref fileDUTPattern); break;
                    case "pad-open-short": 
                        PadOpenShortMethod(ref fileDUTPattern); break;
                }

                fileDUTPattern.SaveFile(pathToSaveFolder + "\\" + newName);
            }
        }

        private void OpenMethod(ref Curve fileDUTPattern)
        {
            int countOfPoints = _fileOpenPattern.CountOfPoints;
            for (int i = 1; i <= countOfPoints; i++)
            {
                double[] openPatternPoints = _fileOpenPattern.GetPoints(i);

                Matrix 
                       open = new Matrix(openPatternPoints),
                       DUT = new Matrix(fileDUTPattern.GetPoints(i));

                Matrix res = (DUT.FromSToY - open.FromSToY).FromYToS;

                fileDUTPattern.ChangePoints(i, res.A.Re, res.A.Im, res.C.Re, res.C.Im, res.B.Re, res.B.Im, res.D.Re, res.D.Im);
            }
        }

        private void L2LMethod(ref Curve fileDUTPattern)
        {
            int countOfPoints = _fileLinePattern.CountOfPoints;
            for (int i = 1; i <= countOfPoints; i++)
            {
                double[] linePatternPoints = _fileLinePattern.GetPoints(i);

                Matrix 
                       line = new Matrix(linePatternPoints),
                       twoLine = new Matrix(_fileTwoLinePattern.GetPoints(i)),
                       DUT = new Matrix(fileDUTPattern.GetPoints(i));

                Matrix
                    aLine = line.FromSToA,
                    aTwoLine = twoLine.FromSToA;

                Matrix 
                       PP = aLine * aTwoLine.Reverse * aLine,
                       PR = PP.FromPPToPR,
                       PL = PP.FromPPToPL,
                       L = PL.Reverse * aLine * PR.Reverse;

                Matrix
                    res = ((PL * L).Reverse * DUT.FromSToA * (L * PR).Reverse).FromAtoS;

                fileDUTPattern.ChangePoints(i, res.A.Re, res.A.Im, res.C.Re, res.C.Im, res.B.Re, res.B.Im, res.D.Re, res.D.Im);
            }
        }

        private void OpenShortMethod(ref Curve fileDUTPattern)
        {
            int countOfPoints = _fileOpenPattern.CountOfPoints;
            for (int i = 1; i <= countOfPoints; i++)
            {
                double[] openPatternPoints = _fileOpenPattern.GetPoints(i);

                Matrix 
                       open = new Matrix(openPatternPoints),
                       shortM = new Matrix(_fileShortPattern.GetPoints(i)),
                       DUT = new Matrix(fileDUTPattern.GetPoints(i));

                Matrix
                    yOpen = open.FromSToY,
                    yShort = shortM.FromSToY,
                    yDUT = DUT.FromSToY;

                Matrix
                    yRes = ((yDUT - yOpen).Reverse - (yShort - yOpen).Reverse).Reverse,
                    res = yRes.FromYToS;

                fileDUTPattern.ChangePoints(i, res.A.Re, res.A.Im, res.C.Re, res.C.Im, res.B.Re, res.B.Im, res.D.Re, res.D.Im);
            }
        }

        private void PadOpenShortMethod(ref Curve fileDUTPattern)
        {
            int countOfPoints = _fileOpenPattern.CountOfPoints;
            for (int i = 1; i <= countOfPoints; i++)
            {
                double[] openPatternPoints = _fileOpenPattern.GetPoints(i);

                Matrix
                       pad = new Matrix(_filePadPattern.GetPoints(i)),
                       open = new Matrix(openPatternPoints),
                       shortM = new Matrix(_fileShortPattern.GetPoints(i)),
                       DUT = new Matrix(fileDUTPattern.GetPoints(i));

                Matrix
                    yPad = pad.FromSToY,
                    yOpen = open.FromSToY,
                    yShort = shortM.FromSToY,
                    yDUT = DUT.FromSToY;

                Matrix
                    yRes = ((yDUT - yPad).Reverse - (yShort - yPad).Reverse).Reverse - ((yOpen - yPad).Reverse - (yShort - yPad).Reverse).Reverse,
                    res = yRes.FromYToS;

                fileDUTPattern.ChangePoints(i, res.A.Re, res.A.Im, res.C.Re, res.C.Im, res.B.Re, res.B.Im, res.D.Re, res.D.Im);
            }
        }
    }

    public class Curve
    {
        private string _pathToFile; // путь к файлу с точками
        public string PathToFile
        {
            get { return _pathToFile; }
        }

        private int _countOfPoints = 0; // количество точек кривой
        public int CountOfPoints
        {
            get { return _countOfPoints; }
        }

        private string _strFreqDim;

        // массив значений координат X точек ( _massOfPoints[0] ) и Y точек в порядке по возраствнию индекса : |S11| - _massOfPoints[1], alpha(S11) - _massOfPoints[2] (и так далее), |S21|, alpha(S21), |S12|, alpha(S12), |S22|, alpha(S22)
        private double[][] _massOfPoints = new double[9][];

        private double[] _startPoints;

        private List<string> comments = new List<string>();

        // строка с конфигурацией s2p файла. Пример: # Hz S DB R 50
        public string SettingsLine
        {
            get { return "# " + _strFreqDim + " " + _typeOfFile + " " + _formatOfPoints + " " + _r + " " + _strLoadImpedance; }
        }

        private string _formatOfPoints;
        public string FormatOfPoints
        {
            get { return _formatOfPoints; }
        }

        private double _loadImpedance;
        public double LoadImpedance
        {
            get { return _loadImpedance; }
        }

        private string _typeOfFile;
        public string TypeOfFile
        {
            get { return _typeOfFile; }
        }

        // символ R в конфигурационной строке
        private string _r;

        private string _strLoadImpedance;

        public string NameOfFile
        {
            get { return Path.GetFileName(_pathToFile); }
        }

        public Curve(string pathToFile)
        {
            _pathToFile = pathToFile;
            LoadFile(pathToFile);

            // сохраняем начальные точки фазы
            string formatOfPoints = _formatOfPoints.ToUpper();
            if (formatOfPoints == "MA" || formatOfPoints == "DB")
                _startPoints = GetPoints(1);
        }

        // небезопасно
        public double[] GetMasOfY(int indexOfSandA)
        {
            return _massOfPoints[indexOfSandA];
        }

        // небезопасно
        public double[] GetMasOfX()
        {
            return _massOfPoints[0];
        }

        public double[] GetPoints(int numberOfFrequency)
        {
            double[] res = new double[9];
            for (int i = 0; i < 9; i++)
                res[i] = _massOfPoints[i][numberOfFrequency];
            return res;
        }

        public void AddNewComment(string line)
        {
            comments.Insert(0, "! " + line);
        }

        public void SetFrequencyDimension(string desireFormat)
        {
            double freqMult = 1;
            string desireFormatUp = desireFormat.ToUpper();
            string currentFormat = _strFreqDim.ToUpper();

            if (desireFormatUp != "HZ" && desireFormatUp != "KHZ" && desireFormatUp != "MHZ" && desireFormatUp != "GHZ")
            {
                return;
            }

            if (currentFormat == "HZ")
            {
                switch (desireFormatUp)
                {
                    case "HZ": freqMult = 1; break;
                    case "KHZ": freqMult = 1e-3; break;
                    case "MHZ": freqMult = 1e-6; break;
                    case "GHZ": freqMult = 1e-9; break;
                }
            }
            if (currentFormat == "KHZ")
            {
                switch (desireFormatUp)
                {
                    case "HZ": freqMult = 1e3; break;
                    case "KHZ": freqMult = 1; break;
                    case "MHZ": freqMult = 1e-3; break;
                    case "GHZ": freqMult = 1e-6; break;
                }
            }
            if (currentFormat == "MHZ")
            {
                switch (desireFormatUp)
                {
                    case "HZ": freqMult = 1e6; break;
                    case "KHZ": freqMult = 1e3; break;
                    case "MHZ": freqMult = 1; break;
                    case "GHZ": freqMult = 1e-3; break;
                }
            }
            if (currentFormat == "GHZ")
            {
                switch (desireFormatUp)
                {
                    case "HZ": freqMult = 1e9; break;
                    case "KHZ": freqMult = 1e6; break;
                    case "MHZ": freqMult = 1e3; break;
                    case "GHZ": freqMult = 1; break;
                }
            }

            for (int i = 1; i <= _countOfPoints; i++)
            {
                _massOfPoints[0][i] *= freqMult;
            }
            _strFreqDim = desireFormat;
        }

        public void SetFormatOfPoints(string desireFormat)
        {
            string currentFormat = _formatOfPoints.ToUpper();
            string desireFormatUp = desireFormat.ToUpper();

            if (desireFormatUp != "MA" && desireFormatUp != "RI" && desireFormatUp != "DB")
            {
                return;
            }

            if (currentFormat == "MA")
            {
                switch (desireFormatUp)
                {
                    case "RI": ConvertFromMAToRI(); break;
                    case "DB": ConvertFromMAToDB(); break;
                }
            }

            if (currentFormat == "RI")
            {
                switch (desireFormatUp)
                {
                    case "MA": ConvertFromRIToMA(); break;
                    case "DB": ConvertFromRIToDB(); break;
                }
            }

            if (currentFormat == "DB")
            {
                switch (desireFormatUp)
                {
                    case "MA": ConvertFromDBToMA(); break;
                    case "RI": ConvertFromDBToRI(); break;
                }
            }

            _formatOfPoints = desireFormat;
        }

        private double ToRad(double x)
        {
            return Math.PI * x / 180;
        }

        private double ToDegree(double x)
        {
            return 180 * x / Math.PI;
        }

        void PointFromRIToMA(ref double x, ref double y)
        {
            double
                re = x,
                im = y;
            x = Math.Sqrt(re * re + im * im);
            y = ToDegree(Math.Atan(im / re));
        }

        private void PointFromRIToDB(ref double x, ref double y)
        {
            double
                re = x,
                im = y;
            x = 20 * Math.Log10(Math.Sqrt(re * re + im * im));
            y = ToDegree(Math.Atan(im / re));
        }

        private void PointFromMAToRI(ref double x, ref double y)
        {
            double
                M = x,
                A = y;
            x = M * Math.Cos( ToRad(A) );
            y = M * Math.Sin( ToRad(A) );
        }

        private double PointFromMAToDB(double x)
        {
            return 20 * Math.Log10(x);
        }

        private double PointFromDBToMA(double x)
        {
            return Math.Pow(10, x / 20);
        }

        private void PointFromDBToRI(ref double x, ref double y)
        {
            double
                M = Math.Pow(10, x / 20),
                A = y;
            x = M * Math.Cos(ToRad(A));
            y = M * Math.Sin(ToRad(A));
        }

        private void ConvertFromRIToMA()
        {
            for (int i = 1; i <= _countOfPoints; i++)
            {
                PointFromRIToMA(ref _massOfPoints[1][i], ref _massOfPoints[2][i]);
                PointFromRIToMA(ref _massOfPoints[3][i], ref _massOfPoints[4][i]);
                PointFromRIToMA(ref _massOfPoints[5][i], ref _massOfPoints[6][i]);
                PointFromRIToMA(ref _massOfPoints[7][i], ref _massOfPoints[8][i]);
            }
            AfterConvertPhaseProcessing();
        }

        private void ConvertFromRIToDB()
        {
            for (int i = 1; i <= _countOfPoints; i++)
            {
                PointFromRIToDB(ref _massOfPoints[1][i], ref _massOfPoints[2][i]);
                PointFromRIToDB(ref _massOfPoints[3][i], ref _massOfPoints[4][i]);
                PointFromRIToDB(ref _massOfPoints[5][i], ref _massOfPoints[6][i]);
                PointFromRIToDB(ref _massOfPoints[7][i], ref _massOfPoints[8][i]);
            }
            AfterConvertPhaseProcessing();
        }

        private void ConvertFromMAToRI()
        {
            for (int i = 1; i <= _countOfPoints; i++)
            {
                PointFromMAToRI(ref _massOfPoints[1][i], ref _massOfPoints[2][i]);
                PointFromMAToRI(ref _massOfPoints[3][i], ref _massOfPoints[4][i]);
                PointFromMAToRI(ref _massOfPoints[5][i], ref _massOfPoints[6][i]);
                PointFromMAToRI(ref _massOfPoints[7][i], ref _massOfPoints[8][i]);
            }
        }

        private void ConvertFromMAToDB()
        {
            for (int i = 1; i <= _countOfPoints; i++)
            {
                _massOfPoints[1][i] = PointFromMAToDB(_massOfPoints[1][i]);
                _massOfPoints[3][i] = PointFromMAToDB(_massOfPoints[3][i]);
                _massOfPoints[5][i] = PointFromMAToDB(_massOfPoints[5][i]);
                _massOfPoints[7][i] = PointFromMAToDB(_massOfPoints[7][i]);
            }
        }

        private void ConvertFromDBToRI()
        {
            for (int i = 1; i <= _countOfPoints; i++)
            {
                PointFromDBToRI(ref _massOfPoints[1][i], ref _massOfPoints[2][i]);
                PointFromDBToRI(ref _massOfPoints[3][i], ref _massOfPoints[4][i]);
                PointFromDBToRI(ref _massOfPoints[5][i], ref _massOfPoints[6][i]);
                PointFromDBToRI(ref _massOfPoints[7][i], ref _massOfPoints[8][i]);
            }
        }

        private void ConvertFromDBToMA()
        {
            for (int i = 1; i <= _countOfPoints; i++)
            {
                _massOfPoints[1][i] = PointFromDBToMA(_massOfPoints[1][i]);
                _massOfPoints[3][i] = PointFromDBToMA(_massOfPoints[3][i]);
                _massOfPoints[5][i] = PointFromDBToMA(_massOfPoints[5][i]);
                _massOfPoints[7][i] = PointFromDBToMA(_massOfPoints[7][i]);
            }
        }

        private void LoadFile(string pathToFile)
        {
            string[] fileDump = File.ReadAllLines(pathToFile);

            List<int> posDataLine = new List<int>();
            int pos = -1;
            foreach (string line in fileDump)
            {
                pos++;
                if (line[0] == '!')
                {
                    comments.Add(line);
                    continue;
                }
                if (line[0] == '#')
                {
                    ParseSettingsLine(line);
                    continue;
                }
                posDataLine.Add(pos);
            }
            
            // сохраняем количество точек
            _countOfPoints = posDataLine.Count;

            // выделяем память
            for (int i = 0; i < 9; i++)
            {
                _massOfPoints[i] = new double[fileDump.Length + 1];
            }

            // парсинг
            // желательно исправить на ноль - начало
            int numOfPoint = 0;
            foreach (int posLine in posDataLine)
            {
                numOfPoint++;
                ParseDataLine(fileDump[posLine], numOfPoint);
            }
        }

        private string PointToStr(double x, double y)
        {
            return x.ToString("0.##########E+000", System.Globalization.CultureInfo.InvariantCulture) + " "
                + y.ToString("0.##########E+000", System.Globalization.CultureInfo.InvariantCulture);
        }

        private string FreqPointToStr(double x)
        {
            return x.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void ChangePoints(int freqPoint, double x11, double y11, double x21, double y21, double x12, double y12, double x22, double y22)
        {
            _massOfPoints[1][freqPoint] = x11;
            _massOfPoints[2][freqPoint] = y11;
            _massOfPoints[3][freqPoint] = x21;
            _massOfPoints[4][freqPoint] = y21;
            _massOfPoints[5][freqPoint] = x12;
            _massOfPoints[6][freqPoint] = y12;
            _massOfPoints[7][freqPoint] = x22;
            _massOfPoints[8][freqPoint] = y22;
        }

        public void SaveFile(string path)
        {
            List<string> masToFile = new List<string>();
            masToFile.AddRange(comments);
            masToFile.Add(SettingsLine);

            for (int i = 1; i <= _countOfPoints; i++)
            {
                masToFile.Add( FreqPointToStr(_massOfPoints[0][i]) + " " +
                    PointToStr(_massOfPoints[1][i], _massOfPoints[2][i]) + " " +
                    PointToStr(_massOfPoints[3][i], _massOfPoints[4][i]) + " " +
                    PointToStr(_massOfPoints[5][i], _massOfPoints[6][i]) + " " +
                    PointToStr(_massOfPoints[7][i], _massOfPoints[8][i])
                    );
            }

            File.WriteAllLines(path, masToFile);
        }

        private void ParseDataLine(string s, int numOfPoints)
        {
            bool readyToParse = false;
            int num = 0, start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!readyToParse && s[i] != ' ')
                {
                    start = i;
                    readyToParse = true;
                }
                if (s[i] == ' ' && readyToParse)
                {
                    string temp = s.Substring(start, i - start);
                     _massOfPoints[num][numOfPoints] = Double.Parse(temp, System.Globalization.CultureInfo.InvariantCulture);
                    num++;
                    readyToParse = false;
                }
            }

            if (readyToParse)
            // дочитываем последний токен
            {
                string temp = s.Substring(start, s.Length - start);
                _massOfPoints[num][numOfPoints] = Double.Parse(temp, System.Globalization.CultureInfo.InvariantCulture);
                num++;
                readyToParse = false;
            }
        }

        private void ParseSettingsLine(string s)
        {
            bool readyToParse = false;
            int num = 0, start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!readyToParse && s[i] != ' ')
                {
                    start = i;
                    readyToParse = true;
                }
                if (s[i] == ' ' && readyToParse)
                {
                    num++;
                    string temp = s.Substring(start, i - start);
                    SetParameter(temp, num);
                    readyToParse = false;
                }
            }
            if (readyToParse) // дочитываем последний токен
            {
                num++;
                string temp = s.Substring(start, s.Length - start);
                SetParameter(temp, num);
                readyToParse = false;
            }
        }

        private void SetParameter(string s, int n)
        {
            switch (n)
            {
                case 2: // частота
                    {
                        _strFreqDim = s;
                        s.ToUpper();
                        switch (s)
                        {
                            case "GHZ":
                               // _freqMult = 1;
                                break;
                            case "MHZ":
                               // _freqMult = 1e-3;
                                break;
                            case "KHZ":
                              //  _freqMult = 1e-6;
                                break;
                            case "HZ":
                               // _freqMult = 1e-9;
                                break;
                        }
                    }
                    break;
                case 3:  // параметр, скорее всего S
                    {
                        _typeOfFile = s;
                    }
                    break;
                case 4:  // размерность DB либо MA либо RI
                    {
                        _formatOfPoints = s;
                        s.ToUpper();
                        if (s != "DB" && s != "MA" && s != "RI")
                            MessageBox.Show("Неверная строка конфигурации в s2p файле (размерность точек)!");
                    }
                    break;
                case 5:  // R
                    {
                        _r = s;
                    }
                    break;
                case 6: // импеданс нагрузки
                    {
                        _strLoadImpedance = s;
                        try
                        {
                            _loadImpedance = Double.Parse(s);
                        }
                        catch
                        {
                            MessageBox.Show("Неверная строка конфигурации в s2p файле (импеданс)!");
                        }
                    }
                    break;
            }
        }

        public void ProcessingOfCurvePhase()
        {
            // выравниваем выбранные кривые
            for (int i = 1; i <= _countOfPoints; i++)
            {
                for (int k = 2; k <= 8; k += 2)
                {
                    while (_massOfPoints[k][i] - _massOfPoints[k][i - 1] > 180)
                        _massOfPoints[k][i] -= 360;
                }
            }
        }

        public void EliminateJumpOfPhaseAftConv()
        {
            // выравниваем выбранные кривые
            for (int i = 1; i <= _countOfPoints; i++)
            {
                for (int k = 2; k <= 8; k += 2)
                {
                    while (_massOfPoints[k][i] - _massOfPoints[k][i - 1] > 170)
                        _massOfPoints[k][i] -= 180;
                }
            }
        }

        public void SyncWithOriginalFirstPoints()
        {
            int[] circle = new int[9];
            for (int i = 2; i <= 8; i+=2)
            {
                int k = (int) Math.Floor((Math.Abs(_startPoints[i]) / 180) + 0.1);
                if (_startPoints[i] < 0)
                    k = -k;
                circle[i] = k;
            }

            for (int i = 1; i <= _countOfPoints; i++)
            {
                for (int k = 2; k <= 8; k += 2)
                {
                    _massOfPoints[k][i] += 180 * circle[k];
                }
            }
        }

        public void AfterConvertPhaseProcessing()
        {
            EliminateJumpOfPhaseAftConv();
            if (_startPoints != null) 
                SyncWithOriginalFirstPoints();
        }

        public void SubstrateCurve(Curve calibrCurve)
        {
            // калибруем только |S21|, alpha(S21), |S12|, alpha(S12)
            for (int i = 1; i <= _countOfPoints; i++)
            {
                for (int k = 3; k <= 6; k++)
                    this._massOfPoints[k][i] -= calibrCurve._massOfPoints[k][i];
            }
        }

        public void AddCurve(Curve calibrCurve)
        {
            // калибруем только |S21|, alpha(S21), |S12|, alpha(S12)
            for (int i = 1; i <= _countOfPoints; i++)
            {
                for (int k = 3; k <= 6; k++)
                    this._massOfPoints[k][i] += calibrCurve._massOfPoints[k][i];
            }
        }
    }
}
