export interface Exercise {
  id: string;
  name: string;
  description: string;
  sets: number;
  reps: number;
}

export interface Workout {
  id: string;
  name: string;
  description: string;
  date: string;
  exercises: Exercise[];
}
