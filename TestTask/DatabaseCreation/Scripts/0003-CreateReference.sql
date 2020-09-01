ALTER TABLE [dbo].[time_reports]  WITH CHECK ADD  CONSTRAINT [FK_time_reports_employees] FOREIGN KEY([employee_id])
REFERENCES [dbo].[employees] ([id])
GO

ALTER TABLE [dbo].[time_reports] CHECK CONSTRAINT [FK_time_reports_employees]
GO