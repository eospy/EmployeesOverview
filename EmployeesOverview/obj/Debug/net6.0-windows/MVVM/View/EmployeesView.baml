   M S B A M L   `   `   `  ����L  HEmployeesOverview, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:EmployeesOverviewEmployeesOverview  5   	   S.clr-namespace:EmployeesOverview.MVVM.ViewModel EmployeesOverview.MVVM.ViewModel  5   	   "    EmployeesOverview.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:EmployeesOverview     5   	   D	viewModel.clr-namespace:EmployeesOverview.MVVM.ViewModel     5   	     � Title$  Сотрудники��5	   	   $	��600��5
   	   $	��920��5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   
������  � DataContext 5      9   3EmployeesOverview.MVVM.ViewModel.EmployeesViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   6+   �� 5      6   �� 5      $	��200 �6   6+   .+�5   
   � $��0��6   
�������.+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      .+�5      �� $��Отделы��6   
������ $��0q�5      
���������5       �� *OpenDepartmentsCommand+5"      �� 5#      $��Сериализация��6   
������ $��0q�5%      
���������5'      �� *OpenSerializationCommand+5)      5*      5,      &   System.Windows.Controls.DataGrid  5-   
   $��1��6   
�������   RowBackground
 �����   AutoGenerateColumns$ False��50         AlternatingRowBackground
 �������52      �� *	Employees+ �� SelectedItem 53      �� *SelectedEmployee+	   Columns	 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 20 57   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 58   %   �� *Id+  59      $
 Имя��6%    5:   %   �� *Name+  5;      $
 Фамилия��6%    5<   %   �� *	Surname+  5=      $
 
Отдел��6%    5>   %   �� *Department.Name+  5?      $
 Должность��6%   $ 80 5@   %    5A   %   �� *
Position+  5B      $
 Зарплата��6%    5C   %   �� *Salary+5E      � 5F   
   $��2��6   
������� � ColumnDefinitions 5H      �� 5I      $	��100 �6#   �� 5J      $	��100 �6#   �� 5K      $	��200 �6#   .+�5M      �� $ Vertical=�6   $��0��5N      .+�5P      �� $��Имя��6   �� 5Q      $��Фамилия��6   �� 5R      $��
Отдел��6   �� 5S      $��Должность��6   �� 5T      $��Зарплата��6   �� 5U      $��Добавить��6   $��0q�5V      ��5W      �� *AddEmployeeCommand+5Z      5\      �� 5]      $ Vertical=�6   $��1��5^       � 	Resources 5`       �� 
TargetType �� Property �� Value��%W   '��       �� 5a      " ��6   .�5b      ��  � ��$ 0,7,0,0q�63   5c      5d      .+�5e      �� ��6   �� *NameTextBox+.��67   5g      �� 5h      ��6   �� *SurnameTextBox+.��6;   5j      �� 5k       �� DisplayMemberPath$
 Name��5m      ��5k      �� *Departments+ 5l      �� *SelectedDepartment+5o      �� 5p      ��6   �� *PositionTextBox+.��6;   5r      �� 5s      ��6   �� *SalaryTextBox+.��69   5u      5w      �� 5x      $ Vertical=�6   $��Center=�5y      $��2��5z       5|      ��%W   '��       �� 5}      " ��6   .�5~      ��  � ��$ 0,7,0,0q�63   5      5�      .+�5�      �� $��Сотрудник��6   $��16(�5�      �� 5�      $��16(�5�      ��5�      �� *SelectedEmployee.Name+5�      �� 5�      $��16(�6   ��5�      �� *SelectedEmployee.Surname+�� 5�      $��16(�6   ��5�      �� *SelectedEmployee.Position+�� 5�      $��16(�6   ��5�      �� *SelectedEmployee.Salary+�� 5�      $%��Внести изменения��6   $��16(�5�      ��5�      �� *SaveChangesCommand+5�      5�      5�      5�      5�      