   M S B A M L   `   `   `  ����L  HEmployeesOverview, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:EmployeesOverview.MVVM.ViewEmployeesOverview.MVVM.View  5   	   S.clr-namespace:EmployeesOverview.MVVM.ViewModel EmployeesOverview.MVVM.ViewModel  5   	   3    -EmployeesOverview.MVVM.View.SerializationView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:EmployeesOverview.MVVM.View     5   	   D	viewModel.clr-namespace:EmployeesOverview.MVVM.ViewModel     5   	     � Title$  Сериализация��5	   	   $	��600��6   $	��920��6+    � DataContext 5
      =   7EmployeesOverview.MVVM.ViewModel.SerializationViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�5      
�������.+�5      �� $2��,Получить список отделов��6   
�������
������ ��5      �� *GetDepartmentsListCommand+5      �� 5      $��Сохранить��6   
�������
������ ��5      �� *SaveFileCommand+5       �� 5!      $��Загрузить��6   
�������
������ ��5$      �� *DownloadFileCommand+5&      5'      � 5(   
   $��1��6   .+�5*      �� .��5+      �� $	��Top=�5,      $��2��5-   5   ��6   �� *DepartmentsList+5/      50      52      54      55      