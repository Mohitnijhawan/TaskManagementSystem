import z from "zod";
import { StatusTask, TaskPriority } from "../../models/enums/enums";

export const taskSchema=z.object({

    title:z.string().nonempty("Title is Required"),
    description:z.string().nonempty("Description is Required"),
    status:z.nativeEnum(StatusTask),
    priority:z.nativeEnum(TaskPriority),
    dueDate:z.coerce.date().optional()

})


